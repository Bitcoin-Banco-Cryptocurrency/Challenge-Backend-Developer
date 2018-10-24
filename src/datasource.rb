require 'json'

# Datasource
module Datasource
  # Read the Json file and save the data in a Hash
  def self.init
    @data_hash = {}
    @params = {}
    print("---Reading Json file \n")
    file = File.read('./books.json')
    @data_hash = JSON.parse(file)

    @data_hash
  end

  # Search for book name passed in URL

  def self.search_params_name(answer, params)
    return answer if params['Name'].nil?

    answer = answer.select { |book| book['name'].include? params['Name'] }
    params.delete('Name')
    answer
  end

  # Save the order parameter

  def self.search_params_sort(params)
    return if params['Sort'].nil?

    sort = params['Sort']
    params.delete('Sort')
    sort
  end

  # Search for specifications, use the params passed in URL. Check if exist in
  # json file then return a response

  def self.search_params_specifications(answer, params)
    params.each do |key, value|
      current_key = key.capitalize
      next unless answer.first['specifications'].key?(current_key.to_s)

      #convert hash to string and search if have substring value
      answer = answer.select { |book| book['specifications'][current_key].to_s.include? value }
    end
    answer
  end

  # Main function of search
  def self.search(params)
    answer = @data_hash
    @params = params

    answer = search_params_name(answer, @params)
    sort = search_params_sort(@params)
    answer = search_params_specifications(answer, @params)

    return answer.sort_by { |book| book['price'] } if sort == 'asc'
    return answer.sort_by { |book| -book['price'] } if sort == 'desc'

    answer
  end
end
