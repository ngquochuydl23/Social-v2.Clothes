/**
 * Title: Driver segment of this project
 * Description: All driver level task execute here
 * Author: Hasibul Islam
 * Date: 10/03/2023
 */

/* external import */
const mongoose = require("mongoose");

/* internal imports */
const app = require("./app");
const consoleMessage = require("./utils/console.util");

/* database connection */
/* establish server port */
app.listen(3001, () => {


  /**
  * Title: Driver segment of this project
  * Description: All driver level task execute here
  * Author: Hasibul Islam
  * Date: 10/03/2023
  */

  /* external import */
  const { configurePostgresDb } = require('./db/dbConfig')
  /* internal imports */
  const app = require("./app");
  const consoleMessage = require("./utils/console.util");

  /* database connection */
  /* establish server port */
  app.listen(3002, async () => {



    await configurePostgresDb();
  });


});
