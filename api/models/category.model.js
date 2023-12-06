const { sequelize } = require('../db/dbConfig')
const { DataTypes } = require('sequelize');
const Subcategory = require('./subcategory.model')

const Category = sequelize.define('Category', {
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
  }
}, {
  timestamps: true
});

Category.hasMany(Subcategory, {
  foreignKey: 'categoryId'
});
Subcategory.belongsTo(Category);

module.exports = Category;
