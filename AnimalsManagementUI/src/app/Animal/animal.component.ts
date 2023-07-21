import { Component, OnInit } from '@angular/core';
import { Animal } from './animal.model';
import { AnimalService } from './animal.service';

@Component({
  selector: 'app-animal',
  templateUrl: './animal.component.html',
  styleUrls: ['./animal.component.css']
})
export class AnimalComponent implements OnInit {
  animals: Animal[] = [];
  newAnimalName: string = '';

  constructor(private animalService: AnimalService) { }

  ngOnInit(): void {
    this.fetchAnimals();
  }

  fetchAnimals(): void {
    this.animalService.getAnimals().subscribe((animals) => {
      this.animals = animals;
    });
  }

  addAnimal(): void {
    if (this.newAnimalName.trim()) {
      const newAnimal: Animal = { name: this.newAnimalName.trim() };
      this.animalService.addAnimal(newAnimal).subscribe(() => {
        this.fetchAnimals();
        this.newAnimalName = '';
      });
    }
  }

  removeAnimal(name: string): void {
    this.animalService.removeAnimal(name).subscribe(() => {
      this.fetchAnimals();
    });
  }
}
