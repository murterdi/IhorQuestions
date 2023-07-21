import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Animal } from './animal.model';

@Injectable({
  providedIn: 'root'
})
export class AnimalService {
  private apiUrl = 'https://localhost:7004/api/animals';

  constructor(private http: HttpClient) { }

  getAnimals(): Observable<Animal[]> {
    return this.http.get<Animal[]>(this.apiUrl);
  }

  addAnimal(animal: Animal): Observable<Animal> {
    return this.http.post<Animal>(this.apiUrl, animal);
  }

  removeAnimal(name: string): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${name}`);
  }
}
