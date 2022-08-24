import datetime
import json
import paho.mqtt.client as mqtt
import psycopg2

Broker = "95.217.2.100"
Port = 1883
Topic = "chengeta/notifications"
Username = "chengeta_user"
Password = "chengeta2022"
# Function to make connection with db
def DbConnect():
    try:
        db_conn = psycopg2.connect(
        database="postgres", user='postgres', password='1234qwer', host='145.24.222.88', port= '8001'
        )
        cursor = db_conn.cursor()
        # Executing a SQL query
        cursor.execute("SELECT version();")
        # Fetch result
        record = cursor.fetchone()
        print("-    You are connected to - ", record, "\n")
        return db_conn, cursor
    except (Exception) as error:
        print("Error while connecting to PostgreSQL", error)
    

def ConnectMqtt() -> mqtt:
    def on_connect(client, userdata, flags, rc):
        if(rc==0):
            print("-    Connected to broker")
        else:
            print("Connection failed")
    client = mqtt.Client()
    client.username_pw_set(Username, Password)
    client.on_connect = on_connect
    client.connect(Broker, Port, 60)
    return client


def subscribe(client: mqtt, db_conn, cursor) -> None:
    def on_message(client, userdata, msg):
        payload_jsonstring = msg.payload.decode()
        payload = json.loads(payload_jsonstring)
        print(payload)
        try:
            query = (
                payload["nodeId"],
                str(payload["latitude"]), str(payload["longitude"]), payload["sound_type"],
                payload["probability"], payload["sound"], int((payload["time"]))
            )
            cursor.execute("INSERT INTO mqttdata(id, latitude, longitude, soundtype, probability, sound, time) VALUES (%s, %s, %s, %s, %s, %s, %s)", query)
            db_conn.commit()
            cursor.execute("SELECT time FROM mqttdata")
            dates = cursor.fetchall()            
            Currentdate = int(datetime.datetime.now().timestamp() - 86400 )
            if dates[0][0] < Currentdate:
                cursor.execute("DELETE FROM  mqttdata WHERE time < %s", (Currentdate))
                db_conn.commit()
        except Exception as e:
            print('Run time error: ', e)
    client.subscribe(Topic)
    client.on_message = on_message
    client.loop_forever()
client = ConnectMqtt()
db = DbConnect()
print(db)
subscribe(client, db[0], db[1])