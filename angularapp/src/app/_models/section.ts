import { BulletPoint } from "./bulletPoint";

export interface Section {
  id: number;
  title: string;
  description: string | null;
  bulletPoints: BulletPoint[];
}
