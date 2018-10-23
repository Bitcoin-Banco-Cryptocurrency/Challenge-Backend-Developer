
module Controller

##Get the query passed by URL and return an array of parameters to search
##Request came in format: method path query
##Query start with '?' and is divide by '&' for each parameters
  def Controller.getUrlParams(request)
    params = nil
    method, full_path = request.split(' ')
    path, query = full_path.split('?')
    unless query.nil?
     params = query.split('&')
    end
    return params
  end

##Build the response to client in HTTP protocol
  def Controller.responseToClient(answer)
    status, headers, body = app.call({})
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
    params = Controller.getUrlParams(request)

    app = Proc.new do
       ['200', {'Content-Type' => 'text/html'}, ["Hello world! #{params}"]]
     end

    responseServer(app)

  end
end
