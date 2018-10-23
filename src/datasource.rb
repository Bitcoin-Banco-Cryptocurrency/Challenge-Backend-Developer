
require 'json'

module Datasource

  data_hash = {}

  #Read the Json file and save the data in a Hash
  def Datasource.init
    print("---Reading Json file \n")
    file = File.read('books.json')
    data_hash = JSON.parse(file)

    print("Successfully \n")
  end

end
