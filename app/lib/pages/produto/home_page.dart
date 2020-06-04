import 'package:app/drawer_list.dart';
import 'package:app/pages/produto/produto_listview.dart';
import 'package:flutter/material.dart';

class HomePage extends StatefulWidget {
  @override
  _HomePageState createState() => _HomePageState();
}

class _HomePageState extends State<HomePage> with SingleTickerProviderStateMixin<HomePage> {
  @override
  Widget build(BuildContext context) {
    return DefaultTabController(
      length: 2,
      child: Scaffold(
        appBar: AppBar(
          title: Text("Loja"),
          bottom: TabBar(tabs: <Widget>[
            Tab(text: "Camisetas",),
            Tab(text: "Canecas",)
          ],),
        ),
        body: TabBarView(children: <Widget>[
          ProdutosListView("1"),
          ProdutosListView("2"),
        ],),
        drawer: DrawerList(),
      ),
    );
  }
}
