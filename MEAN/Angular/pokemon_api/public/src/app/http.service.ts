import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class HttpService {

  constructor(private _http: HttpClient) {
    this.getPokemon();
  }
  getPokemon(){
    let sneasel = this._http.get('https://pokeapi.co/api/v2/pokemon/sneasel');
    sneasel.subscribe(data => {
      console.log(`${data.name}'s abilities are ${data.abilities[0].ability.name}, ${data.abilities[1].ability.name}, and ${data.abilities[2].ability.name}.`);
      
      var urls = {};
      data.abilities.forEach(a =>{
        urls[a.ability.name] = a.ability.url
      });
      
      for (var ability in urls){
        this._http.get(urls[ability])
        .subscribe(result => {
          console.log(`${result.pokemon.length} pokemon have the ${result.name} ability: `)
          var pokes = "";
          result.pokemon.forEach(p => {
            pokes += `${p.pokemon.name}, `;
          })
          console.log(pokes);
        })
      }
    });
  }
}
