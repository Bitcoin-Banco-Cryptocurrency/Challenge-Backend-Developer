module.exports.escapeRegExp = function(string) {
  return string.replace(/[.*+?^${}()|[\]\\]/g, '\\$&') // $& means the whole matched string
}

module.exports.sortBookPrice = function sortNumber(a,b) {
    return a.price - b.price;
}

module.exports.sortBookPriceDesc = function sortNumber(a,b) {
    return b.price - a.price;
}
