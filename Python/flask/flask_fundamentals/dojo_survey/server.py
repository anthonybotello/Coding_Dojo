from flask import Flask, render_template, request, url_for
app = Flask(__name__)

@app.route('/')
def index():
    return render_template('index.html')

@app.route('/result',methods=['POST'])
def show_result():
    print(request.form)
    return render_template('result.html',name_on_template=request.form['name'],dojo_on_template=request.form['dojo_location'],language_on_template=request.form['fav_language'],comment_on_template=request.form['comment'])





if __name__ == '__main__':
    app.run(debug=True)