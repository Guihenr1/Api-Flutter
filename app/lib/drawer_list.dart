import 'package:app/pages/login/login_page.dart';
import 'package:app/utils/nav.dart';
import 'package:flutter/material.dart';

class DrawerList extends StatelessWidget {
  @override
  Widget build(BuildContext context) {
    return Drawer(
      child: ListView(
        children: <Widget>[
          UserAccountsDrawerHeader(
            accountName: Text("Guilherme Pompilio"),
            accountEmail: Text("guilherme.pomp@gmail.com"),
            currentAccountPicture: CircleAvatar(
              backgroundColor: Color.fromRGBO(100, 100, 100, 10),
              // backgroundImage: AssetImage("assets/images/car1.jpg"),
            ),
          ),
          ListTile(
            leading: Icon(Icons.star),
            title: Text("Favoritos"),
            subtitle: Text("Mais informações"),
            trailing: Icon(Icons.arrow_forward),
            onTap: () {
              print("Item 1");
              Navigator.pop(context);
            },
          ),
          ListTile(
            leading: Icon(Icons.help),
            title: Text("Ajuda"),
            subtitle: Text("Me ajuda"),
            trailing: Icon(Icons.arrow_forward),
            onTap: () {
              print("Item 1");
              Navigator.pop(context);
            },
          ),
          ListTile(
            leading: Icon(Icons.exit_to_app),
            title: Text("Sair"),
            trailing: Icon(Icons.arrow_forward),
            onTap: () => _onClickLogout(context),
          )
        ],
      ),
    );
  }

  _onClickLogout(BuildContext context) {
    Navigator.pop(context);
    push(context, LoginPage(), replace: true);
  }
}
