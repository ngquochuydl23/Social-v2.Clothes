function prefixMime(mimetype) {
  return mimetype.substring(0, mimetype.lastIndexOf('/'))
}

module.exports = { prefixMime }