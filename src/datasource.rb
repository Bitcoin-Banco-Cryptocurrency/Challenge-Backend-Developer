require 'json'

# Datasource
module Datasource
  # Read the Json file and save the data in a Hash
  def self.init
    @data_hash = {}
    @params = {}
    print("---Reading Json file \n")
    file = File.read('books.json')
    @data_hash = JSON.parse(file)

    print("Successfully \n")
  end

  def self.search_params_name(answer, params)
    return answer if params['Name'].nil?

    answer = answer.select { |book| book['name'].include? params['Name'] }
    params.delete('Name')
    answer
  end

  def self.search_params_sort(params)
    return if params['Sort'].nil?

    sort = params['Sort']
    params.delete('Sort')
    sort
  end

  def self.search_params_specifications(answer, params)
    params.each do |key, value|
      current_key = key.tr('-', ' ').capitalize
      next unless answer.first['specifications'].key?(current_key.to_s)

      answer.select! { |book| book['specifications'][current_key].include? value }
    end
    answer
  end

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
