import api from "./api";

interface LoginRequest {
  username: string;
  password: string;
}

interface LoginResponse {
  token: string;
}

const loginUser = async (credentials: LoginRequest): Promise<LoginResponse> => {
  const response = await api.post<LoginResponse>("/auth/login", credentials);
  return response.data;
};

export default loginUser;
