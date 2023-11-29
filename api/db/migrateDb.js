const { Sequelize } = require('sequelize');
const { Client } = require('pg');
const User = require('../models/user.model');
const { configurePostgresDb } = require('./dbConfig');


configurePostgresDb()
    .then(() => {
        
        User.sync({ alter: true });
    })
    .catch((err) => {
        
    })






