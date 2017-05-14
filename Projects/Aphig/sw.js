importScripts('./cache-polyfill.js');

self.addEventListener('install', function(e) {
 e.waitUntil(
   caches.open('Aphig').then(function(cache) {
     return cache.addAll([
       './BigProject.html',
       './BigProject.html?homescreen=1',
       './?homescreen=1',
       './map.html',
       './media.html',
       './1.jpg',
       './2.jpg',
       './3.jpg',
       './4.jpg',
       './5.jpg',
       './6.jpg',
       './7.jpg'
     ]);
   })
 );
});


self.addEventListener('fetch', function(event) {
console.log(event.request.url);
event.respondWith(
caches.match(event.request).then(function(response) {
return response || fetch(event.request);
})
);
});