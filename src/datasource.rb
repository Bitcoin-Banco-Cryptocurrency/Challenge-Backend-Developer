
require 'json'



module Datasource



  #Read the Json file and save the data in a Hash
  def Datasource.init
    @data_hash = {}
    print("---Reading Json file \n")
    file = File.read('books.json')
    @data_hash = JSON.parse(file)

    print("Successfully \n")
  end


  def Datasource.search(params)
    answer = @data_hash

    unless params["Name"].nil?
      answer.select! { | book | book["name"].include? params["Name"]}
      params.delete("Name")
    end

    unless params["Sort"].nil?
      sort = params["Sort"]
      params.delete("Sort")
    end

    params.each do |key, value|
      current_key = key.tr('-', ' ').capitalize
      next unless answer.first["specifications"].has_key?(current_key.to_s)
      answer.select! { | book | book["specifications"][current_key].include? value}
    end

    if sort == "asc"
      return answer.sort_by { | h | h["price"]}
    elsif sort == "desc"
       return answer.sort_by { | h | -h["price"]}
    end

    return answer
  end

end
