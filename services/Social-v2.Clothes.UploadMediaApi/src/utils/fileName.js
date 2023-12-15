<<<<<<< HEAD
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
=======
const crypto = require('crypto');

function generateFileName(file) {
  console.log("File" + file);
  const hash = crypto.createHash('md5').update(file.buffer).digest('hex');

  // Add timestamp for uniqueness
  const timestamp = Date.now();

  console.log(hash);
  return `${hash}-${timestamp}`;
}

module.exports = {
  generateFileName
>>>>>>> 1cc9f323600225d34c8d2b46560cc806fbbb51e6
}