import 'package:app/pages/login/usuario.dart';
import 'package:app/utils/alert.dart';
import 'package:app/utils/nav.dart';
import 'package:app/widgets/app_button.dart';
import 'package:app/widgets/app_text.dart';
import 'package:flutter/material.dart';
import 'package:flutter/services.dart';

import '../api_response.dart';
import '../produto/home_page.dart';
import 'login_api.dart';

class LoginPage extends StatefulWidget {
  @override
  _LoginPageState createState() => _LoginPageState();
}

class _LoginPageState extends State<LoginPage> {
  final _formKey = GlobalKey<FormState>();

  final _tLogin = TextEditingController();

  final _tPass = TextEditingController();

  final _focusPass = FocusNode();

  bool _showProgress = false;

  @override
  void initState() {
    super.initState();
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: Text("Loja"),
      ),
      body: _body(),
    );
  }

  _body() {

    return Form(
      key: _formKey,
      child: Container(
        padding: EdgeInsets.all(16),
        child: ListView(
          children: <Widget>[
            AppText(
              "Login",
              controller: _tLogin,
              validate: _validateLogin,
              textInputType: TextInputType.emailAddress,
              textInputAction: TextInputAction.next,
              nextFocus: _focusPass,
            ),
            SizedBox(
              height: 10,
            ),
            AppText(
              "Senha",
              password: true,
              controller: _tPass,
              validate: _validatePass,
              textInputType: TextInputType.number,
              focusNode: _focusPass,
            ),
            SizedBox(
              height: 20,
            ),
            AppButton(
              "Login",
              onPressed: _onClickLogin,
              showProgress: _showProgress,
            ),
          ],
        ),
      ),
    );
  }

  _onClickLogin() async {
    bool formOk = _formKey.currentState.validate();
    if (!formOk) {
      return;
    }

    state(true);

    String login = _tLogin.text;
    String pass = _tPass.text;

    ApiResponse response = await LoginApi.login(login, pass);

    if(response.ok){
      Usuario user = response.result;

      print(">>> $user");

      push(context, HomePage(), replace: true);

      state(false);
    } else {
      alert(context, response.msg);

      state(false);
    }
  }

  String _validateLogin(String text) {
    if (text.isEmpty) {
      return "Login inválido";
    }
    return null;
  }

  String _validatePass(String text) {
    if (text.isEmpty) {
      return "Senha inválida";
    }
    return null;
  }

  @override
  void dispose() {
    super.dispose();
  }

  void state(bool value){
    setState(() {
      _showProgress = value;
    });
  }
}
