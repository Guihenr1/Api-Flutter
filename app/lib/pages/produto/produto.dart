class Produto {
  String id;
  String name;
  String description;
  String image;
  int category;

  Produto(
      {this.id, this.name, this.description, this.image, this.category});

  Produto.fromJson(Map<String, dynamic> json) {
    id = json['id'];
    name = json['name'];
    description = json['description'];
    image = json['image'];
    category = json['category'];
  }

  Map<String, dynamic> toJson() {
    final Map<String, dynamic> data = new Map<String, dynamic>();
    data['id'] = this.id;
    data['name'] = this.name;
    data['description'] = this.description;
    data['image'] = this.image;
    data['category'] = this.category;
    return data;
  }
}
