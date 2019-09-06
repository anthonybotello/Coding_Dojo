from django.conf.urls import url
from . import views


urlpatterns = [
    url(r'^$',views.home,name="home"),
    url(r'^add$',views.add,name="add"),
    url(r'^add_book$',views.add_book,name="add_book"),
    url(r'^(?P<book_id>\d+)$',views.book_info,name="book_info"),
]