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
}