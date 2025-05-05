export namespace config {
	
	export class LoginServer {
	    Name: string;
	    IP: string;
	    Port: number;
	    PacketID: string;
	
	    static createFrom(source: any = {}) {
	        return new LoginServer(source);
	    }
	
	    constructor(source: any = {}) {
	        if ('string' === typeof source) source = JSON.parse(source);
	        this.Name = source["Name"];
	        this.IP = source["IP"];
	        this.Port = source["Port"];
	        this.PacketID = source["PacketID"];
	    }
	}

}

