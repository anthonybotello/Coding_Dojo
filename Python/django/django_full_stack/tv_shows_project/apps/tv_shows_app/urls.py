from django.conf.urls import url
from . import views


urlpatterns = [
    url(r'^$',views.index),
    url(r'^shows$',views.shows),
    url(r'^shows/new$',views.new_show),
    url(r'^add_show$',views.add_show),
    url(r'^shows/(?P<num>\d+)$',views.show_info),
    url(r'^shows/(?P<num>\d+)/destroy$',views.destroy),
    url(r'^shows/(?P<num>\d+)/edit$',views.edit_show),
    url(r'^process_edit$',views.process_edit)
]