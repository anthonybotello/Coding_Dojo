from flask import Flask
app = Flask(__name__)

@app.route('/')
def hello_world():
    return "Hello World!"

@app.route('/dojo')
def dojo():
    return 'Dojo!'

@app.route('/say/<visitor>')
def say(visitor):
    if visitor.isalpha():
        print(visitor)
        return f"Hi {visitor}!"
    else:
        return "you done goofed"

@app.route('/repeat/<number>/<phrase>')
def repeat(number,phrase):
    if number.isdigit() and phrase.isalpha():
        print(number)
        print(phrase)
        return (phrase +' ')*int(number)
    else:
        return "you done goofed"

@app.route('/<undefined_route>')
def undefined_route(undefined_route):
    print(undefined_route)
    return "Sorry! No response Try again."

if __name__ == '__main__':
    app.run(debug=True)