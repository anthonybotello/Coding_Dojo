let students = [
    {name: 'Remy', cohort: 'Jan'},
    {name: 'Genevieve', cohort: 'March'},
    {name: 'Chuck', cohort: 'Jan'},
    {name: 'Osmund', cohort: 'June'},
    {name: 'Nikki', cohort: 'June'},
    {name: 'Boris', cohort: 'June'}
];

function studentInfo(list)
{
    list.forEach(student => {
        console.log(`Name: ${student.name}, Cohort: ${student.cohort}`);
    });
}

studentInfo(students);


let users = {
    employees: [
        {'first_name':  'Miguel', 'last_name' : 'Jones'},
        {'first_name' : 'Ernie', 'last_name' : 'Bertson'},
        {'first_name' : 'Nora', 'last_name' : 'Lu'},
        {'first_name' : 'Sally', 'last_name' : 'Barkyoumb'}
    ],
    managers: [
       {'first_name' : 'Lillian', 'last_name' : 'Chambers'},
       {'first_name' : 'Gordon', 'last_name' : 'Poe'}
    ]
 };

function peopleInfo(obj)
{
    for (people in obj)
    {
        console.log(`${people}`.toUpperCase());
        var i = 1;
        obj[people].forEach(person => {
            console.log(`${i} - ${person.last_name.toUpperCase()}, ${person.first_name.toUpperCase()} - ${person.last_name.length + person.first_name.length}`);
            i++;
        });
    }
}

peopleInfo(users);