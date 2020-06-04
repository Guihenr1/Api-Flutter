import 'package:app/pages/produto/produto.dart';
import 'package:http/http.dart' as http;
import 'dart:convert' as convert;

class TipoProduto {
  static final String camisetas = "1";
  static final String canecas = "2";
}

class ProdutosApi {
  static Future<List<Produto>> getProdutos(String tipo) async {
    var url = 'http://4824c3e032cb.ngrok.io/api/Product/$tipo';

    print("GET > $url");

    var response = await http.get(url);

    String json = response.body;
    print(json);

    List list = convert.json.decode(json);

    List<Produto> produtos = list.map<Produto>((map) => Produto.fromJson(map)).toList();

    return produtos;
  }
}