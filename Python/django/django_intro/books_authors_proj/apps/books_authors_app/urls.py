from django.conf.urls import url
from . import views


urlpatterns = [
    url(r'^$',views.index),
    url(r'^add_book$',views.add_book),
    url(r'^books/(?P<num>\d+)',views.book_info),
    url(r'^books/add_author$',views.add_author_to_book),
    url(r'^authors$',views.authors),
    url(r'^add_author$',views.add_author),
    url(r'^authors/(?P<num>\d+)',views.author_info),
    url(r'^authors/add_book$',views.add_book_to_author)
]