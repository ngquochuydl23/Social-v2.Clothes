const express = require('express');
const cors = require('cors');
const bodyParser = require('body-parser');
const morgan = require('morgan');
const multer = require('multer');
const app = express();
const _ = require('lodash');
const config = require('./config.json');
const PORT = config.port;
const {
  generateFileName
} = require('./utils/fileName');
const sharp = require('sharp');
const {
  configureMongoDb
} = require('./db')
const MediaSchema = require('./models/media')
const {
  prefixMime
} = require('./utils/mime')
const {
  mediaType
} = require('./constant/mediaConstant');

var upload = multer({
  limits: {
    fileSize: config.limitFileSize
  }
})

app.post("/api/upload", upload.any(), async function (req, res) {
  const files = req.files;

  if (!req.files) {
    res.status(400)
    return res.send({
      statusCode: 400,
      error: {
        message: "No file uploaded"
      }
    })
  }

  var medias = await Promise.all(_.map(files, async (file) => {

    var buffer;

    if (prefixMime(file.mimetype) === mediaType.IMAGE) {
      buffer = await sharp(file.buffer)
        .resize(undefined, undefined)
        .jpeg({
          quality: 50
        })
        .grayscale()
        .toBuffer();
    } else {
      buffer = file.buffer
    }

    const newDoc = await MediaSchema.create({
      fileName: generateFileName(file),
      buffer: buffer,
      mime: file.mimetype,
      size: Buffer.byteLength(buffer)
    });

    return {
      url: config.serverUrl + newDoc.fileName,
      mime: newDoc.mime,
    }
  }));

  return res.send({
    statusCode: res.statusCode,
    result: {
      medias
    }
  })
});

app.get("/:fileName", async function (req, res) {
  const mediaDoc = await MediaSchema
    .findOne()
    .where({
      fileName: req.params.fileName
    })
    .select({
      buffer: 1
    })
    .exec();

  if (!mediaDoc) {
    res.status(400)
    return res.send({
      statusCode: 400,
      error: {
        message: "File not found"
      }
    })
  }

  res.end(mediaDoc.buffer);
});

app.use(cors());
app.use(bodyParser.json());
app.use(bodyParser.urlencoded({
  extended: true
}));
app.use(morgan('dev'));


app.listen(PORT, () => {
  configureMongoDb();
  console.log(`App is listening on port ${PORT}.`)
});