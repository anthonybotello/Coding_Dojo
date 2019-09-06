function userLanguages(users)
{
    users.forEach(user => {
        var langs = "";
        user.languages.forEach(language => {
            langs += language;
            var idx = user.languages.indexOf(language);
            if (idx < user.languages.length - 2)
            {
                langs += ", ";
            }
            else if (idx < user.languages.length - 1)
            {
                langs += ", and ";
            }
        });
        var interests = [];
        for (item in user.interests)
        {
           user.interests[item].forEach(interest => {
               interests.push(interest);
           });
        }
        var ints = "";
        for (var i = 0; i < interests.length; i++)
        {
            ints += interests[i];
            if (i === interests.length - 2)
            {
                ints += ", and ";
            }
            else if (i < interests.length - 2)
            {
                ints += ", ";
            }
        }  
        console.log(user.fname + " " + user.lname + " knows " + langs + ".");
        console.log(user.fname + " is also interested in " + ints + ".");
    });
}

users = [
    {
      fname: "Kermit",
      lname: "the Frog",
      languages: ["Python", "JavaScript", "C#", "HTML", "CSS", "SQL"],
      interests: {
        music: ["guitar", "flute"],
        dance: ["tap", "salsa"],
        television: ["Black Mirror", "Stranger Things"]
      }
    },
    {
      fname: "Winnie",
      lname: "the Pooh",
      languages: ["Python", "Swift", "Java"],
      interests: {
        food: ["honey", "honeycomb"],
        flowers: ["honeysuckle"],
        mysteries: ["Heffalumps"]
      }
    },
    {
      fname: "Arthur",
      lname: "Dent",
      languages: ["JavaScript", "HTML", "Go"],
      interests: {
        space: ["stars", "planets", "improbability"],
        home: ["tea", "yellow bulldozers"]
      }
    }
  ]

  userLanguages(users);