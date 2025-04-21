import ReducedItem from "./ReducedItem";

class ScriptReduced implements ReducedItem {
  id: number;
  name: string;
  getContent(): string {
    throw new Error("Method not implemented.");
  }
}
