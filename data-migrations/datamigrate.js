let mongoose = require('mongoose');
let fs = require('fs');
let path = require('path');

let args = process.argv;
if(args.length < 3) {
    console.log('Please enter the json file name to migrate (ex: node datamigrate.js test.json)');
    process.exit();
}
let fileName = args[2];
const words = JSON.parse(fs.readFileSync(path.join(__dirname + '/data/' + fileName), 'utf-8'));

mongoose.Promise = global.Promise;
//mongoose.connect('mongodb://admin:abc123!@localhost');
mongoose.connect("mongodb://admin:abc123!@localhost/dictionary", { useNewUrlParser: true });


console.log('Data migraion => File : ' + fileName);

let WordDetail = mongoose.model('WordDetail', {
  English_HW: {
    type: String
  },
  POS: {
    type: String
  },
  Tamil_HW: {
    type: String
  },
  Tamil_Unicode: {
      type: String
  },
  Tamil_Lexeme: {
    type: String
  },
  Irula_Lexeme: {
    type: String
  },
  Pania_Lexeme: {
    type: String
  },
  Toda_Lexeme: {
    type: String
  },
  English_Gloss: {
    type: String
  },
  Semantic_Category: {
    type: String
  },
  Irula_Metadata: {
    type: String
  }
});

async function loadData() {
  try {
    await WordDetail.insertMany(words);
    console.log('Data migrated!');
    process.exit();
  } catch(e) {
    console.log(e);
    process.exit();
  }
}

loadData();