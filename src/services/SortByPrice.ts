import SortService from './SortService';

/**
 * @author Rodrigo Costa
 * @module Services
 */

module Services {
    /**
     * SortService.
     */
    export class SortByPrice extends SortService {

        /**
         * QuickSort Algorithm
         * @param array 
         */
        public sort(array, asc = true) {
            if (array.length <= 1) {
              return array;
            }
            var pivot = array[0];
            var left = []; 
            var right = [];
          
            for (var i = 1; i < array.length; i++) {
                this.sortFunction(array[i], pivot, asc) ? left.push(array[i]) : right.push(array[i]);
            }
            return this.sort(left, asc).concat(pivot, this.sort(right, asc));
        };
        /**
         * Sort Rules
         * @param obj1 
         * @param obj2 
         * @param asc 
        */
        sortFunction(obj1:any,obj2:any,asc:boolean): boolean{
            if(obj1.price < obj2.price) return asc;
            return !asc;
        }
    }
}
export default Services.SortByPrice;