var fs = require('fs');
var obj;
var filePath = __dirname + '/test.json';
fs.readFile(filePath, 'utf8', function (err, data) {
  if (err) throw err;
  obj = JSON.parse(data);
  console.log(obj.Sheet1[2].POS);
});
console.log('completed!');