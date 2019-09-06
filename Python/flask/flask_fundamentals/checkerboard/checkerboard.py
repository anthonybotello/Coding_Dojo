from flask import Flask, render_template
app = Flask(__name__)

@app.route('/')
def standard_board():
    return render_template('checkerboard.html',num_columns=8,num_rows=8,color_1='red',color_2='black')

@app.route('/<x>')
def x_columns(x):
    return render_template('checkerboard.html',num_columns=int(x),num_rows=8,color_1='red',color_2='black')
@app.route('/<x>/<y>')
def x_colums_y_rows(x,y):
    return render_template('checkerboard.html',num_columns=int(x),num_rows=int(y),color_1='red',color_2='black')

@app.route('/<x>/<y>/<color1>/<color2>')
def custom_board(x,y,color1,color2):
    return render_template('checkerboard.html',num_columns=int(x),num_rows=int(y),color_1=color1,color_2=color2)

if __name__ == '__main__':
    app.run(debug=True)