from django.conf.urls import url
from . import views


urlpatterns = [
    url(r'^$',views.home,name="home"),
    url(r'^add_book$',views.add_book,name="add"),
    url(r'^(?P<book_id>\d+)$',views.book_info,name="book_info"),
    url(r'^like/(?P<book_id>\d+)$',views.like_unlike,name="like-unlike"),
    url(r'^delete/(?P<book_id>\d+)$',views.delete_book,name="delete"),
    url(r'^update$',views.update_book,name="update"),
    url(r'^favorites/(?P<user_id>\d+)$',views.user_favorites,name="user_favorites")
]