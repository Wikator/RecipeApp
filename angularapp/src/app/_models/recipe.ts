import { Ingredient } from "./ingredient";
import { Section } from "./section";
import { Photo } from "./photo";

export interface Recipe {
  id: number;
  title: string;
  description: string;
  createdAt: Date;
  ingredients: Ingredient[];
  sections: Section[];
  photos: Photo[];
}
