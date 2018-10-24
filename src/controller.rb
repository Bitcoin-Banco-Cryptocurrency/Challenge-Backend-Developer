require 'uri'
# Controller
module Controller
  ## Get the query passed by URL and return an array of parameters to search
  ## Request came in format: method path query
  ## Query start with '?' and is divide by '&' for each parameters

  def self.get_url_params(request)
    params = {}
    return params if request.nil?
    _, full_path = request.split(' ')
    path, query = full_path.split('?')
    return params if path.to_s != '/search'

    query = URI.decode(query).force_encoding('UTF-8')
    print query
    unless query.nil?
      query.split('&').each do |p|
        key, value = p.split('=')
        params[key] = value
      end
    end
    params
  end

  ## Build the response to client in HTTP protocol

  def self.response_to_client(answer, session)
    status, headers, body = answer.call({})
    session.print "HTTP/1.1 #{status}\r\n"
    headers.each do |key, value|
      session.print "#{key}: #{value}\r\n"
    end
    session.print "\r\n"
    body.each do |part|
      session.print part
    end
  end

  ## Format response to client

  def self.create_json_answer(status, msg)
    proc do
      [status, { 'Content-Type' => 'application/json' }, [msg.to_json]]
    end
  end

  ## Format the parameters and find the correct answer to client

  def self.get(session, request)
    puts request

    params = get_url_params(request)
    if params.empty?
      app = create_json_answer('404', 'Page not found.')
      return response_to_client(app, session)
    end
    result = Datasource.search(params)
    app = if result.empty?
            create_json_answer('404', 'Search not found.')
          else
            create_json_answer('200', result)
          end

    response_to_client(app, session)
  end
end
