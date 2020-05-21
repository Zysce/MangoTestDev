import axios from "axios";
import useAuthenticationController from "./authenticationController";

export default () => {
  const { token } = useAuthenticationController();

  const api = axios.create({
    baseURL: `${process.env.REACT_APP_API_URL}/api`,
  });
  api.interceptors.request.use((request) => {
    if (!!request && !!token) {
      if (!request.headers) request.headers = {};
      request.headers["Authorization"] = `Bearer ${token}`;
    }
    return request;
  });

  return {
    get: async (endpoint, config) => {
      return await api.get(endpoint, config);
    },
    post: async (endpoint, data, config) => {
      return await api.post(endpoint, data, config);
    },
    put: async (endpoint, data, config) => {
      return await api.put(endpoint, data, config);
    },
    delete: async (endpoint, config) => {
      return await api.delete(endpoint, config);
    },
    patch: async (endpoint, data, config) => {
      return await api.patch(endpoint, data, config);
    },
  };
};
