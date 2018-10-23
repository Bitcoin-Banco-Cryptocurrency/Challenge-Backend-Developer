
module Controller

##Get the query passed by URL and return an array of parameters to search
##Request came in format: method path query
##Query start with '?' and is divide by '&' for each parameters
  def Controller.getUrlParams(request)
    params = {}
    method, full_path = request.split(' ')
    path, query = full_path.split('?')
    unless query.nil?
     query.split('&').each do |p|
       key, value = p.split('=')
       params[key] = value.tr('-', ' ')
     end
    end
    return params
  end

##Build the response to client in HTTP protocol
  def Controller.responseToClient(answer, session)
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

  def Controller.get(session, request)
    params = getUrlParams(request)

    result = Datasource.search(params)

    app = Proc.new do
       ['200', {'Content-Type' => 'text/html'}, ["Hello world! #{result}"]]
     end

    responseToClient(app, session)

  end
end
