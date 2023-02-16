FROM node:latest
WORKDIR /app/client
COPY React-frontend/package.json ./
RUN npm install
COPY . .
CMD ["npm", "start"]