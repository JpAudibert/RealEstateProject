import axios from 'axios';

interface AuthToken {
  token: string;
}

interface Auth {
  register: (username: string, email: string, password: string) => Promise<unknown>;
  login: (username: string, password: string) => Promise<AuthToken>;
  logout: () => Promise<unknown>;
  getCurrentUser: () => AuthToken;
}

const register = (username: string, email: string, password: string) => {
  return axios.post('/auth/signup', {
    username,
    email,
    password,
  });
};

const login = async (username: string, password: string) => {
  const response = await axios.post('/auth', {
    username,
    password,
  });
  // if (response.data.username) {
  localStorage.setItem('user', JSON.stringify(response.data));
  // }
  return response.data;
};

const logout = async () => {
  localStorage.removeItem('user');
  const response = await axios.post('/auth/signout');
  return response.data;
};

const getCurrentUser = () => {
  return JSON.parse(localStorage.getItem('user')!);
};

const AuthService: Auth = {
  register,
  login,
  logout,
  getCurrentUser,
};

export default AuthService;
