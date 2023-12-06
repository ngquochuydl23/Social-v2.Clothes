const { Sequelize } = require('sequelize');

const sequelize = new Sequelize(
    "Social-v2.Clothes.Dev",
    "postgres",
    "1",
    {
        host: "localhost",
        dialect: 'postgres'
    }
);

module.exports = {
    sequelize,
    configurePostgresDb() {
        return new Promise((resolve, reject) => {
            sequelize
                .authenticate()
                .then(() => {
                    resolve();
                })
                .catch((err) => {
                    console.log(err);
                    reject();
                })
        })
    }
}