# Controller
module Controller
## Get the query passed by URL and return an array of parameters to search
## Request came in format: method path query
## Query start with '?' and is divide by '&' for each parameters

  def self.get_url_params(request)
    params = {}
    _, full_path = request.split(' ')
    _, query = full_path.split('?')
    unless query.nil?
      query.split('&').each do |p|
        key, value = p.split('=')
        params[key] = value.tr('-', ' ')
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

  def self.get(session, request)
    params = get_url_params(request)

    result = Datasource.search(params)

    app = proc do
      ['200', { 'Content-Type' => 'text/html' }, ["Hello world! #{result}"]]
    end

    response_to_client(app, session)
  end
end
