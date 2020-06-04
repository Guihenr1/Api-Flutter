import 'package:app/pages/produto/produto.dart';
import 'package:app/pages/produto/produto_api.dart';
import 'package:flutter/material.dart';

class ProdutosListView extends StatefulWidget {
  String tipo;

  ProdutosListView(this.tipo);

  @override
  _ProdutosListViewState createState() => _ProdutosListViewState();
}

class _ProdutosListViewState extends State<ProdutosListView>
    with AutomaticKeepAliveClientMixin<ProdutosListView> {
  @override
  bool get wantKeepAlive => true;

  @override
  Widget build(BuildContext context) {
    super.build(context);
    return _body();
  }

  _body() {
    Future<List<Produto>> future = ProdutosApi.getProdutos(widget.tipo);

    return FutureBuilder(
      future: future,
      builder: (context, snapshot) {
        if (snapshot.hasError) {
          return Center(
            child: Text(
              "Não foi possível buscar os produtos",
              style: TextStyle(
                color: Colors.red,
                fontSize: 22,
              ),
            ),
          );
        }

        if (!snapshot.hasData) {
          return Center(
            child: CircularProgressIndicator(),
          );
        }

        List<Produto> produto = snapshot.data;
        return _listView(produto);
      },
    );
  }

  Container _listView(List<Produto> produto) {
    return Container(
      padding: EdgeInsets.all(16),
      child: ListView.builder(
          itemCount: produto != null ? produto.length : 0,
          itemBuilder: (context, index) {
            Produto c = produto[index];

            return Card(
              color: Colors.grey[100],
              child: Container(
                padding: EdgeInsets.all(10),
                child: Column(
                  crossAxisAlignment: CrossAxisAlignment.start,
                  children: <Widget>[
                    Center(
                      child: Image.network(
                            "https://cdn.awsli.com.br/800x800/613/613696/produto/34655886/9077409139.jpg",
                        width: 250,
                      ),
                    ),
                    Text(
                      c.name,
                      maxLines: 1,
                      overflow: TextOverflow.ellipsis,
                      style: TextStyle(fontSize: 25),
                    ),
                    Text(
                      "descrição...",
                      style: TextStyle(fontSize: 16),
                    ),
                    ButtonBar(
                      children: <Widget>[
                        FlatButton(
                          child: const Text('Detalhes'),
                          onPressed: () {
                            /* ... */
                          },
                        ),
                        FlatButton(
                          child: const Text('Share'),
                          onPressed: () {
                            /* ... */
                          },
                        ),
                      ],
                    ),
                  ],
                ),
              ),
            );
          }),
    );
  }
}
