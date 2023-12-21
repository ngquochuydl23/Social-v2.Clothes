function createEncodeFileName(fileName) {
  return Buffer.from(fileName).toString('base64')
}

function decodeFileParam(fileParam) {
  return Buffer.from(fileParam, 'base64').toString('ascii')
}

function generateFileName(file) {
  return "social-v2.clothes" + '-' + Date.now()
}

module.exports = {
  generateFileName,
  createEncodeFileName,
  decodeFileParam
}