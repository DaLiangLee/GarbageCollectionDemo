export class SubCategory {
    id: number;
    itemName: string;
    CategoryId: number;
}
export class Category {
  CategoryId: number;
  CategoryName: string;
}
export class Garbage {
  SubCategoryId: number;
  CreatedTime: Date;
  RecyclingQty: number;
}

