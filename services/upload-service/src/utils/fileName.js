const mime = require('mime');

function generateFileName(file) {
  return "social-v2" + '-' + Date.now()
}

module.exports = { generateFileName }

