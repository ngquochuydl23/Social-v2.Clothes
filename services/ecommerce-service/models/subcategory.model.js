const { sequelize } = require('../db/dbConfig')
const { DataTypes } = require('sequelize');

const Subcategory = sequelize.define('Subcategory', {
  id: {
    allowNull: false,
    primaryKey: true,
    type: DataTypes.STRING(100)
  },
  title: {
    allowNull: false,
    type: DataTypes.STRING(100),
  },
  description: {
    allowNull: false,
    type: DataTypes.STRING(255),
  },
  thumbnail: {
    allowNull: false,
    type: DataTypes.STRING(124),
  },
  categoryId: {
    allowNull: false,
    type: DataTypes.STRING(100)
  }
}, {
  timestamps: true
});

module.exports = Subcategory;
