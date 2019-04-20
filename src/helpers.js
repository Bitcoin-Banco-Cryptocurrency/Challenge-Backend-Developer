function to(promise) {
    return promise.then(data => {
        return [null, data];
    })
    .catch(err => [err]);
}

function escape(str) {
   return str.replace(/[.*+?^${}()|[\]\\]/g, '\\$&')
}

function sortPrice(a,b){
    return a.price - b.price;
}

function sortDesc(a,b){
    return a.price - b.price;
}

module.exports = {
    to,
    escape,
    sortPrice,
    sortDesc
}