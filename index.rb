require 'socket'
require './src/datasource.rb'
require './src/controller.rb'

##Open TCP Server
class Server
   def initialize(socket_address, socket_port)
      @server_socket = TCPServer.open(socket_port, socket_address)

      puts 'Started server.........'
      run
   end

   def run
     #wait for client connection, when it happens pass to controller the request made in method 'GET'
     while session = @server_socket.accept
       request = session.gets
       Controller.get(session, request)
       session.close
     end
   end
end

##Read Json File
Datasource.init

##Call server
Server.new( 8080, "localhost" )
