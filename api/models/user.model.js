const { sequelize } = require('../db/dbConfig')
const { DataTypes } = require('sequelize');

const User = sequelize.define('User', {
  id: {
    allowNull: false,
    autoIncrement: true,
    primaryKey: true,
    type: DataTypes.INTEGER
  },
  name: {
    allowNull: false,
    type: DataTypes.STRING(100),
  },
  password: {
    allowNull: false,
    type: DataTypes.STRING(255),
  },
  avatar: {
    allowNull: false,
    type: DataTypes.STRING(255),
  },
  gender: {
    allowNull: false,
    type: DataTypes.STRING(6),
    validate: {
      isIn: [['male', 'female']]
    }
  },
  phone: {
    allowNull: false,
    type: DataTypes.STRING(12),
  },
  role: {
    allowNull: false,
    type: DataTypes.STRING(25),
  },
  address: {
    allowNull: false,
    type: DataTypes.STRING(100),
  },
  dod: {
    allowNull: false,
    type: DataTypes.DATE,
  },
}, {
  timestamps: true
});

module.exports = User;
