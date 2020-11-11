module.exports = async function (context, req) {
  context.log("JavaScript HTTP trigger function processed a request.");
  let temp = "";
  if (req.body.readings && req.body) {
    const allReadings = req.body.readings;
    for (i = 0; i < allReadings.length; i++) {
      temp = allReadings[i].temperature;

      context.log("This is " + allReadings[i].temperature + "something");
      if (temp < 25) {
        allReadings[i].status = "OK";
      } else if (temp < 50) {
        allReadings[i].status = "Critical";
      } else if (temp > 51) {
        allReadings[i].status = "BAD";
      }
    }

    context.res = {
      // status: 200, /* Defaults to 200 */
      body: {
        readings: req.body.readings,
      },
    };
  } else {
    // Bad value
    context.res = {
      status: 400,
      body: "The value of the Temperature in incorrect!",
    };
    return;
  }
};
