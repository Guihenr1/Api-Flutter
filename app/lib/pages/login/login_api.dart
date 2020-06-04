import 'dart:convert';
import 'package:app/pages/login/usuario.dart';
import 'package:http/http.dart' as http;
import '../api_response.dart';

class LoginApi {
  static Future<ApiResponse> login(String login, String senha) async {
    try{
      var url = 'http://4824c3e032cb.ngrok.io/api/user';

      Map<String, String> headers = {
        "Content-Type": "application/json"
      };

      Map params = {
        "username": login,
        "password": senha,
      };

      String s = json.encode(params);

      var response = await http.post(url, body: s, headers: headers);

      print('Response status: ${response.statusCode}');
      print('Response body: ${response.body}');

      Map mapResponse = json.decode(response.body);

      if(response.statusCode == 200){
        final user = Usuario.fromJson(mapResponse);

        return ApiResponse.ok(user);
      }

      return ApiResponse.error("Erro ao tentar realizar login");
    }
    catch(error, exception){
      print("Erro no pages.login $error > $exception");

      return ApiResponse.error("Não foi possível realizar o login");
    }
  }
}