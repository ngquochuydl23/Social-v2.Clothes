const { Sequelize } = require('sequelize');
const { Client } = require('pg');
const User = require('../models/user.model');
const Category = require('../models/category.model');
const Subcategory = require('../models/subcategory.model');
const { configurePostgresDb } = require('./dbConfig');


configurePostgresDb()
    .then(() => {
        
        User.sync({ alter: true });
        Category.sync({ alter: true })
            .then(() => Subcategory.sync({ alter: true }))
    })
    .catch((err) => {

    })






